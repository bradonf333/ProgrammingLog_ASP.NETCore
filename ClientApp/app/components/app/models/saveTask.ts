import { KeyValuePair } from './keyValuePair';

export interface SaveProgrammingTask {
    id: number,
    hours: string,
    description: string,
    summary: string,
    taskDate: string,
    programmingLanguages: KeyValuePair[]
}