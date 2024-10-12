// Declare the module for velocity-animate
declare module 'velocity-animate' {
    interface VelocityOptions {
      duration?: number | string; // Time in ms or predefined values like 'fast', 'slow'
      easing?: string | number[]; // Easing function or Bezier array
      begin?: () => void;         // Callback before animation begins
      complete?: () => void;      // Callback after animation ends
      loop?: number | boolean;    // Number of loops or true for infinite
      delay?: number;             // Delay before animation starts
      display?: string;           // CSS display property, e.g., 'none', 'block'
      visibility?: string;        // CSS visibility property, e.g., 'hidden', 'visible'
      mobileHA?: boolean;         // Hardware acceleration on mobile
    }
  
    interface VelocityStatic {
      (elements: HTMLElement | HTMLElement[], properties: Record<string, any>, options?: VelocityOptions): void;
      (elements: HTMLElement | HTMLElement[], properties: Record<string, any>, duration?: number): void;
    }
  
    // Export velocity as a module
    const Velocity: VelocityStatic;
    export default Velocity;
  }
  