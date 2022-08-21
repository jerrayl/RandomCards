import { useEffect, useState } from "react";
import { HubConnectionBuilder } from '@microsoft/signalr';
import Title from "./Title";
import Game from "./Game";
import { SIGNALR_CODES } from "./utils/constants";

function SignalR() {
    const [connected, setConnected] = useState(false);
    const [connection, setConnection] = useState(null);
    const [gameStarted, setGameStarted] = useState(false);
    const [loggedIn, setLoggedIn] = useState(false);
    const [requests, setRequests] = useState([]);
    const [email, setEmail] = useState("");

    const login = async (emailVariable) => {
        const response = await connection.invoke("login", { email: emailVariable });
        if (response == SIGNALR_CODES.SUCCESS) {
            sessionStorage.setItem('email', emailVariable);
            setLoggedIn(true);
        }
    }

    const sendRequest = async (receiver) => {
        const response = await connection.invoke("sendrequest", { email: receiver });
        if (response == SIGNALR_CODES.SUCCESS) {
            alert("Your request has been sent");
        } else {
            alert(response);
        }
    }

    const acceptRequest = async (sender) => {
        const requestIdentifier = requests.filter(request => request.sender == sender)[0].requestIdentifier;
        await connection.invoke("acceptrequest", { requestIdentifier: requestIdentifier });
    }

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl(`https://localhost:5001/signalr`)
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connected && sessionStorage.email) {
            setEmail(sessionStorage.email);
            login(sessionStorage.email);
        }
    }, [connected])

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(result => {
                    setConnected(true);

                    connection.on('Request', message => {
                        setRequests(currRequests => [message, ...currRequests]);
                    });

                    connection.on('GameStarted', _ => {
                        setGameStarted(true);
                    });
                })
                .catch(e => console.log('Connection failed: ', e));
        }
    }, [connection]);

    return <>{gameStarted ?
        <Game email={email} /> :
        <Title connected={connected} email={email} setEmail={setEmail} loggedIn={loggedIn} login={login} sendRequest={sendRequest} requests={requests} acceptRequest={acceptRequest} />}</>;
}

export default SignalR;
