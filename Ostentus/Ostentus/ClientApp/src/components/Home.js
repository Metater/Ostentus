import React from 'react';

import Alert from 'react-bootstrap/Alert';
import Container from 'react-bootstrap/Container';

export function Home() {
  return (
    <Container className="p-4">
      <Alert>
        <Alert.Heading>
          Welcome to Ostentus!
        </Alert.Heading>
      </Alert>
    </Container>
  );
};