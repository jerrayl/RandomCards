import title from "./assets/title.png";

function Game({ gameState, email }) {

    return (
        <div className="flex flex-col items-center font-serif">
            <nav className="bg-stone-700 w-screen h-20 px-12 grid grid-cols-3 flex items-center text-3xl shadow-lg z-10">
                <div className="flex justify-start">
                    <h2 className="text-white">{gameState?.status ? gameState.status : "Game Starting..."}: {gameState?.currentPlayer ? gameState.currentPlayer == email ? "Your turn" : "Opponent's turn" : ""}</h2>
                </div>
                <div className="flex justify-center">
                    <img src={title} className="w-56" alt="title" />
                </div>
                <div className="flex justify-end">
                    <h2 className="text-white">End turn</h2>
                </div>
            </nav>
        </div>
    );
}

export default Game;
