module Main exposing (main)

import Browser
import Html exposing (..)
import Html.Attributes exposing (..)
import Html.Events exposing (onClick, onInput)



-- Main


main =
    Browser.sandbox
        { init = init
        , update = update
        , view = view
        }



-- Model


type alias Model =
    { name : String
    , age : Maybe Int
    , displaymsg : String
    }


init : Model
init =
    { name = ""
    , age = Nothing
    , displaymsg = ""
    }



-- View


view : Model -> Html Msg
view model =
    div []
        [ input [ placeholder "name", value model.name, onInput UserNameChanged ] []
        , input [ placeholder "age", value (ageDisplay model.age), onInput AgeChanged ] []
        , button [ onClick SayHello ] [ text "validate" ]
        , div [] [ text model.displaymsg ]
        ]


ageDisplay : Maybe Int -> String
ageDisplay age =
    case age of
        Nothing ->
            " "

        Just ageValue ->
            String.fromInt ageValue



-- Update


type Msg
    = SayHello
    | UserNameChanged String
    | AgeChanged String


update : Msg -> Model -> Model
update msg model =
    case msg of
        SayHello ->
            { model | displaymsg = model.name ++ getageresponse model.age }

        UserNameChanged newValue ->
            { model | name = newValue }

        AgeChanged newValue ->
            { model | age = String.toInt newValue }


getageresponse : Maybe Int -> String
getageresponse age =
    case age of
        Nothing ->
            "."

        Just ageValue ->
            ",aged " ++ String.fromInt ageValue ++ "."
