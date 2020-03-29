import 'App.scss';
import routes from 'appRouting';
import { loadLoginInfo } from 'auth/+state/actionCreators';
import { isLoadingSessionInfoSelector, isLoggedInSelector } from 'auth/+state/authSelectors';
import { LoginRegister } from 'auth/LoginRegister';
import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { MainPageTemplate } from 'shared/@layout/MainPageTemplate';
import { FullScreenLoading } from 'shared/loading/Loading';

function App() {
  const isLoggedIn = useSelector(isLoggedInSelector);
  const isLoadingSessionInfo = useSelector(isLoadingSessionInfoSelector);
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(loadLoginInfo());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [1]);

  return (
    <div className="App">
      <Router>
        {isLoadingSessionInfo ? (
          <FullScreenLoading />
        ) : isLoggedIn ? (
          <MainPageTemplate menu={routes}>
            <Switch>
              {routes.map((route, i) => (
                <Route key={i} exact={route.exact} path={route.path}>
                  <route.component />
                </Route>
              ))}
            </Switch>
          </MainPageTemplate>
        ) : (
          <LoginRegister />
        )}
      </Router>
    </div>
  );
}

export default App;
