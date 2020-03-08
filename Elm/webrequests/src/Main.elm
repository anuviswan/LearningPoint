module Main exposing (main)
import Html
import Html.Attributes exposing (..)
import Html.Events exposing (..)


-- Main
main =
    Browser.element {init = init, update = update, subscriptions = subscriptions,view = view}
-- Model
type Model = Sucess String
    | Loading
    | Failure

init : () -> (Model,Cmd Msg)
-- View
-- Update