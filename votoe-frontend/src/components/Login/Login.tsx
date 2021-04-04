import React from 'react';
import './Login.scss';
import LoginUseReducer, { initialState } from "../../reducer";

function Login() {
    return (
        <div>
            {LoginUseReducer()}
        </div>
    )
}

export default Login;