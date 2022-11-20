import React from 'react';

import { Button, Alert, Container } from 'react-bootstrap';

export function OnOff() {
  return (
    <Container className="p-4">
      <Alert>
        <Alert.Heading>
          <Button variant="warning" size="lg" onClick={() => fetch("/api/on")}>
            On
          </Button>
          <Button variant="dark" size="lg" onClick={() => fetch("/api/off")}>
            Off
          </Button>
        </Alert.Heading>
      </Alert>
    </Container>
  );
};