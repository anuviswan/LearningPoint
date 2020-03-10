module Main exposing (main)

import Browser
import Html exposing (..)
import Html.Attributes exposing (..)
import Html.Events exposing(..)
import Http
import Json.Decode exposing (Decoder, field, string)

main =
    Browser.element {init=init, update = update, subscriptions  = subscriptions, view = view}

type  Model =
        Loading
        | Failure
        | Loaded String

init : ()->(Model, Cmd Msg)
init _ =
 (Loading, getRandomCatGif )

getRandomCatGif : Cmd Msg
getRandomCatGif=
    Http.get
    {
        url = "https://api.giphy.com/v1/gifs/random?api_key=dc6zaTOxFJmzC&tag=cat"
        ,expect  = Http.expectJson GotData gifDecoder
    }

gifDecoder : Decoder String
gifDecoder = 
    field "data"(field "image_url" string)

type Msg =
    MorePlease
    | GotData (Result Http.Error String)

update : Msg -> Model -> (Model, Cmd Msg)
update msg model =
  case msg of
    MorePlease ->
      (Loading, getRandomCatGif)

    GotData result ->
      case result of
        Ok url ->
          (Loaded url, Cmd.none)

        Err _ ->
          (Failure, Cmd.none)



-- SUBSCRIPTIONS


subscriptions : Model -> Sub Msg
subscriptions model =
  Sub.none



-- VIEW


view : Model -> Html Msg
view model =
  div []
    [ h2 [] [ text "Random Cats" ]
    , viewGif model
    ]


viewGif : Model -> Html Msg
viewGif model =
  case model of
    Failure ->
      div []
        [ text "I could not load a random cat for some reason. "
        , button [ onClick MorePlease ] [ text "Try Again!" ]
        ]

    Loading ->
      text "Loading..."

    Loaded url ->
      div []
        [ button [ onClick MorePlease, style "display" "block" ] [ text "More Please!" ]
        , img [ src url ] []
        ]


