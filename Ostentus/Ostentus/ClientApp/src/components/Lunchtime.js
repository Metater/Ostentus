import React, { useState } from 'react';

import { Button, Alert, Container, ToggleButton, Row, ToggleButtonGroup } from 'react-bootstrap';

export function Lunchtime() {
  return (
    <Container className="p-4">
      <Alert>
        <Button variant="dark" size="lg" onClick={() => fetch("/api/play-pippy-lunchtime")}>
          Test Play Lunchtime
        </Button>
      </Alert>
    </Container>
  );
};