import routes from 'appRouting';
import { isLoggedInSelector } from 'auth/+state/authSelectors';
import { LoginRegister } from 'auth/LoginRegister';
import React from 'react';
import { useSelector } from 'react-redux';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { MainPageTemplate } from 'shared/@layout/MainPageTemplate';
import './App.scss';

function App() {
  const isLoggedIn = useSelector(isLoggedInSelector);
  return (
    <div className="App">
      <Router>
        {isLoggedIn ? (
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
