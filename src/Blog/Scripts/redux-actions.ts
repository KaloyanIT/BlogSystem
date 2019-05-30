export interface IHelloWorldData {
    status: string;
    count?: number;
}

export const RECEIVE_HELLOWORLD = 'RECEIVE_HELLO_WORLD';

export function receiveHelloWorldData(data: IHelloWorldData) {
    return {
        type: RECEIVE_HELLOWORLD,
        data
    }
}