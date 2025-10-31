export const GameList = () => {  }

// import React, { useEffect, useState } from "react";
// import { GameService } from "../../application/services/GameService";
// import { Game } from "../../domain/entities/Game";

// export const GameList = () => {
//   const [games, setGames] = useState([]);

//   useEffect(() => {
//     GameService.getGames()
//       .then(data => {
//         const gameObjects = data.map(g => new Game(g.id, g.title));
//         setGames(gameObjects);
//       })
//       .catch(err => {
//         console.error("Error fetching games:", err);
//         setGames([]);
//       });
//   }, []);

//   return (
//     <div style={{ padding: "20px", fontFamily: "Arial, sans-serif" }}>
//       <h2 style={{ color: "#2c3e50" }}>🎮 Lista de Partidas</h2>
//       {games.length === 0 ? (
//         <p>No hay partidas disponibles.</p>
//       ) : (
//         <ul style={{ listStyle: "none", padding: 0 }}>
//           {games.map(g => (
//             <li
//               key={g.id}
//               style={{
//                 background: "#ecf0f1",
//                 margin: "8px 0",
//                 padding: "10px",
//                 borderRadius: "6px",
//                 boxShadow: "0 1px 3px rgba(0,0,0,0.1)"
//               }}
//             >
//               <strong>{g.title}</strong>
//             </li>
//           ))}
//         </ul>
//       )}
//     </div>
//   );
// };
