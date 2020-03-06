module Main exposing (main)
import Browser
import Html exposing (..)
import Html.Attributes exposing(..)
import Html.Events exposing (onClick)

-- Main

main =
    Browser.sandbox {init=init,update=update,view=view}


type alias Model = Int

init:Model
init = 
    0

-- Update
type Msg = Increment
           | Decrement
           | Reset
           | IncrementBy10
           | DecrementBy10

update : Msg -> Model -> Model
update msg model =
    case msg of
        Increment  ->
            model +1
        Decrement ->
            model - 1
        Reset ->
            0
        IncrementBy10 ->
            model + 10
        DecrementBy10 ->
            model - 10

-- View
view : Model -> Html Msg
view model =
    div[class "jumbotron"]
    [
        div[][h1[][text "Hello World"],h4[][text "From Elm"]],
        button[onClick DecrementBy10][text "-10"],
        button[onClick Decrement][text "-"],
        div[][ text (String.fromInt model)],
        button[onClick Increment][text "+"],
        button[onClick IncrementBy10][text "+10"],
        button[onClick Reset][text "Reset"]
    ]

