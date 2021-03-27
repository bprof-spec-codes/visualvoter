import React, {
  Reducer,
  Dispatch,
  createContext,
  useContext,
  useReducer,
} from "react";
import { initialState } from "./reducer";

/*
export const StateContext = createContext(null);

interface IProvider{
  reducer:any;
  initState:typeof initialState;
  children:any;
}

export const StateProvider:React.FC<IProvider> = ({
  reducer,
  initState,
  children,
}) => {
  const [state, dispatch] = useReducer(reducer, initState);
  const value = { state, dispatch };
  return (
    <StateContext.Provider value={value}>{children}</StateContext.Provider>
  );
};

export const useStateValue = () => useContext(StateContext);
*/
