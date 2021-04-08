import counterReducer from './counter';
import loginReducer from './loginReducer';
import { combineReducers } from 'redux';

export const allReducers=combineReducers({
    counter: counterReducer,
    isLogged: loginReducer,
});

export default allReducers;