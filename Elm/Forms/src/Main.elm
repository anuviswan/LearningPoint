module Main exposing (main)
import Browser
import Html exposing(..)
import Html.Events exposing(onClick)

main =
    Browser.sandbox {init=init,update=update,model=model}


type alias Model =
    {
        username : String
        ,password : String
        ,confirmpassword : String
    }

init:Model
init =
    {
        username = ""
        ,password = ""
        ,confirmpassword = ""
        
    }


-- update
type Msg = UsernameChanged String
    | PasswordChanged String
    | ConfirmPasswordChanged String

update : Msg -> Model -> Model


