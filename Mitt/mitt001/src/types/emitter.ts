// emitter.ts
import mitt from 'mitt'

type Events = {
  foo: string,
  bar: number,
}

export const emitter = mitt<Events>()