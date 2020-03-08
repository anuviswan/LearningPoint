module Main exposing (main)

import Browser
import Html exposing (..)
import Html.Attributes exposing (..)
import Html.Events exposing (onClick, onInput)



-- Main


main =
    Browser.sandbox { init = init, update = update, view = view }


type alias Model =
    { counter : Int
    , content : String
    }


init : Model
init =
    { counter = 0
    , content = "Jia"
    }



-- Update


type Msg
    = Increment
    | Decrement
    | Reset
    | IncrementBy10
    | DecrementBy10
    | TextChange String


update : Msg -> Model -> Model
update msg model =
    case msg of
        Increment ->
            { model | counter = model.counter + 1 }

        Decrement ->
            { model | counter = model.counter - 1 }

        Reset ->
            { model | counter = 0 }

        IncrementBy10 ->
            { model | counter = model.counter + 10 }

        DecrementBy10 ->
            { model | counter = model.counter - 10 }

        TextChange newValue ->
            { model | content = newValue }



-- View


view : Model -> Html Msg
view model =
    div [ class "jumbotron" ]
        [ div [] [ h1 [] [ text ("Hi " ++ model.content) ], h4 [] [ text ("- From Elm (" ++ String.fromInt (String.length model.content) ++ ")") ] ]
        , button [ onClick DecrementBy10 ] [ text "-10" ]
        , button [ onClick Decrement ] [ text "-" ]
        , div [] [ text (String.fromInt model.counter) ]
        , button [ onClick Increment ] [ text "+" ]
        , button [ onClick IncrementBy10 ] [ text "+10" ]
        , button [ onClick Reset ] [ text "Reset" ]
        , input [ placeholder "Please enter your name", value model.content, onInput TextChange ] []
        ]
