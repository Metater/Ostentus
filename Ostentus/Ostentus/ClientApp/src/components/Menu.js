import React from 'react';
import { LinkContainer } from 'react-router-bootstrap'

import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

export function Menu() {
  return (
    <header>
      <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
        <Container>
          <LinkContainer to="/">
            <Navbar.Brand>Home</Navbar.Brand>
          </LinkContainer>

          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
          
          <Nav className="me-auto">
            <LinkContainer to="/onoff">
              <Nav.Link>Button</Nav.Link>
            </LinkContainer>
            <LinkContainer to="/lunchtime">
              <Nav.Link>Lunchtime</Nav.Link>
            </LinkContainer>
          </Nav>

          </Navbar.Collapse>
        </Container>
      </Navbar>
    </header>
  );
};