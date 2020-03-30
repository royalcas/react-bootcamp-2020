import { Activity } from 'dashboard/model/activity';
import { Tip } from 'dashboard/model/tip';
import { FluxAction } from './../../redux/FluxAction';
import { PageState } from './../../redux/PageState';
import { DashboardActionTypes } from './dashboardActionTypes';

export interface DashboardPageData {
  myActivities: PageState<Activity[]>;
  suggestedAcivities: PageState<Activity[]>;
  tip: PageState<Tip>;
}

export interface DashboardState extends PageState<DashboardPageData> {}

export const initialState: DashboardState = {
  isLoading: true,
  hasErrors: false,
  pageData: {
    myActivities: {
      isLoading: true,
      hasErrors: false,
      pageData: [],
    },
    suggestedAcivities: {
      isLoading: true,
      hasErrors: false,
      pageData: [],
    },
    tip: {
      isLoading: true,
      hasErrors: false,
      pageData: null as any,
    },
  },
};

export const reducer = (
  state: DashboardState = initialState,
  action: FluxAction<DashboardActionTypes, Activity[] | Tip | boolean>,
): DashboardState => {
  switch (action.type) {
    case DashboardActionTypes.FetchDashboardInfo:
      return initialState;
    case DashboardActionTypes.FetchMyActivities:
      return {
        ...state,
        pageData: { ...state.pageData, myActivities: { ...state.pageData.myActivities, isLoading: true } },
      };
    case DashboardActionTypes.FetchSuggestedActivities:
      return {
        ...state,
        pageData: { ...state.pageData, suggestedAcivities: { ...state.pageData.suggestedAcivities, isLoading: true } },
      };
    case DashboardActionTypes.FetchTip:
      return {
        ...state,
        pageData: { ...state.pageData, tip: { ...state.pageData.tip, isLoading: true } },
      };
    case DashboardActionTypes.SetMyActivities:
      return {
        ...state,
        pageData: {
          ...state.pageData,
          myActivities: { ...state.pageData.myActivities, pageData: action.payload as Activity[], isLoading: false },
        },
      };
    case DashboardActionTypes.SetSuggestedActivities:
      return {
        ...state,
        pageData: {
          ...state.pageData,
          suggestedAcivities: {
            ...state.pageData.suggestedAcivities,
            pageData: action.payload as Activity[],
            isLoading: false,
          },
        },
      };
    case DashboardActionTypes.SetTip:
      return {
        ...state,
        pageData: {
          ...state.pageData,
          tip: {
            ...state.pageData.suggestedAcivities,
            pageData: action.payload as Tip,
            isLoading: false,
          },
        },
      };
    case DashboardActionTypes.SetError:
      return {
        ...state,
        hasErrors: true,
      };
    default:
      return state;
  }
};

export default reducer;
