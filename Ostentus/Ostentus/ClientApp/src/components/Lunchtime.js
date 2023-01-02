import React, { useState } from 'react';

import { Button, Alert, Container, ToggleButton, Row, ToggleButtonGroup, Form } from 'react-bootstrap';

export function Lunchtime() {
  const [alarmTime, setAlarmTime] = useState("");

  let updateAlarmTime = (time) => {
    fetch("/api/lunchtime/update-alarm-time?time=" + encodeURIComponent(time));
    setAlarmTime(time);
  }

  return (
    <Container className="p-4">
      <Alert>
        <Button variant="dark" size="lg" onClick={() => fetch("/api/play-pippy-lunchtime")}>
          Test Play Lunchtime
        </Button>
      </Alert>
      <Form.Control
        type="time"
        id="alarm-time"
        value={alarmTime}
        onChange={e => updateAlarmTime(e.target.value)}
      />
    </Container>
  );
};