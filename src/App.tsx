import { Button, DatePicker } from 'antd';
import routes from 'appRouting';
import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { MainPageTemplate } from 'shared/@layout/MainPageTemplate';
import './App.scss';

function App() {
  return (
    <div className="App">
      <Router>
        <MainPageTemplate menu={routes}>
          <Switch>
            {routes.map((route, i) => (
              <Route key={i} exact={route.exact} path={route.path}>
                <route.component />
              </Route>
            ))}
          </Switch>
          <DatePicker />

          <Button type="primary" style={{ marginLeft: 8 }}>
            Primary Button
          </Button>
        </MainPageTemplate>
      </Router>
    </div>
  );
}

export default App;
