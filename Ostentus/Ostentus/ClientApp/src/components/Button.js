import React from 'react';

import Alert from 'react-bootstrap/Alert';
import Container from 'react-bootstrap/Container';

export function Button() {
  return (
    <Container className="p-4">
      <Alert>
        <Alert.Heading>
          Button
        </Alert.Heading>
      </Alert>
    </Container>
  );
};