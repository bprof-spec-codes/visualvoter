import React, {
  Reducer,
  Dispatch,
  createContext,
  useContext,
  useReducer,
} from "react";
import { initialState } from "./reducer";

interface Actions {
  type: string;
  value: any;
}

interface Props {
  user: any;
  content: JSX.Element | null;
}

interface ProviderProps {
  reducer: Reducer<Props, Actions>;
  initState: Props;
}

interface InitContrextProps {
  state: Props;
  dispatch: Dispatch<Actions>;
}

export const StateContext = createContext({} as InitContrextProps);

export const StateProvider: React.FC<ProviderProps> = ({
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
