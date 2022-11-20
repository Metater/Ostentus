import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';

import { Home } from './components/Home';
import { OnOff } from './components/Button';
import { Menu } from './components/Menu';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: "/onoff",
    element: <OnOff />
  }
];

export default function App() {
  return (
    <>
      <Menu />
      <Routes>
        {AppRoutes.map((route, index) => {
          const { element, ...rest } = route;
          return <Route key={index} {...rest} element={element} />;
        })}
      </Routes>
    </>
  );
}
