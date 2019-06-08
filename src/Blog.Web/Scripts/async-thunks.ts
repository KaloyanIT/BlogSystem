import { receiveHelloWorldData } from './redux-actions';

export function retrieveData() {
    return (dispatch: <T>(action: any) => T, getState: () => any) => {
        setTimeout(() => {
            dispatch(receiveHelloWorldData({status: 'Data received', count: 5}));
        }, 5000)
    }
}