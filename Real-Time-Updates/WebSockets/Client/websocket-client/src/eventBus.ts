// src/eventBus.ts
import mitt from 'mitt';

// Define types for events
type Events = {
  componentAMessage: string;
  componentBMessage: string;
};

// Create the event bus using mitt and provide types
const eventBus = mitt<Events>();

export default eventBus;
