module Main exposing (main)
import Browser
import Html exposing(..)
import Html.Attributes exposing(..)
import Html.Events exposing (onInput)

main =
    Browser.sandbox {init=init,update=update,view=view}

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
update msg model=
    case msg of
        UsernameChanged newvalue ->
            {model|username = newvalue}
        PasswordChanged newvalue ->
            {model|password = newvalue}
        ConfirmPasswordChanged newvalue ->
            {model|confirmpassword = newvalue}

-- view

view : Model -> Html Msg
view model =
    div[class "jumbotron"]
    [
        div[][
            viewTitle "UserName"
            ,viewInput "text" "User Name" model.username UsernameChanged
        ]
        ,div[][
            viewTitle "Password"
            ,viewInput "password" "Password" model.password PasswordChanged
        ]
        ,div[][
            viewTitle "Confirm Password"
            ,viewInput "password" "Confirm Password" model.confirmpassword ConfirmPasswordChanged
        ]
        ,viewValidation model       
        
    ]
        
viewInput : String -> String -> String -> (String->msg) -> Html msg
viewInput typ pholder val action =
    input[type_ typ, placeholder pholder,value val,onInput action][]

viewTitle : String -> Html msg
viewTitle message =
    text message

viewValidation : Model -> Html msg
viewValidation model =
    if(model.password == model.confirmpassword) then
        div[style "color" "green"][text "ok"]
    else
        div[style "color" "red"][text "password do not match"]



