module Main exposing (main)

import Browser
import Html exposing (Html,text,pre)
import Html.Attributes exposing (..)
import Html.Events exposing (..)
import Http


-- Main


main =
    Browser.element { init = init, update = update, subscriptions = subscriptions, view = view }



-- Model


type Model
    = Success String
    | Loading
    | Failure


init : () -> ( Model, Cmd Msg )
init _ =
    ( Loading
    , Http.get
        { url = "https://elm-lang.org/assets/public-opinion.txt"
        , expect = Http.expectString GotText
        }
    )



-- View
-- Update


type Msg
    = GotText (Result Http.Error String)


update : Msg -> Model -> ( Model, Cmd Msg )
update msg model =
    case msg of
        GotText result ->
            case result of
                Ok fulltext ->
                    ( Success fulltext, Cmd.none )

                Err _ ->
                    ( Failure, Cmd.none )


subscriptions : Model -> Sub Msg
subscriptions model =
    Sub.none


view : Model -> Html Msg
view model =
    case model of
        Failure ->
            text "I was unable to load your book."

        Loading ->
            text "Loading..."

        Success fullText ->
            pre [] [ text fullText ]
