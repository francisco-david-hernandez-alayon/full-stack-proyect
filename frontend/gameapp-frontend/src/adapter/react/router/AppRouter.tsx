import { Routes, Route } from "react-router-dom";
import { HomePage } from "../pages/HomePage.tsx";
import { GamesPage } from "../pages/GamesPage.tsx";
import { CharactersPage } from "../pages/CharactersPage.tsx";
import { BiomesPage } from "../pages/BiomesPage.tsx";
import { EnemiesPage } from "../pages/EnemiesPage.tsx";
import { ItemsPage } from "../pages/ItemsPage.tsx";
import { PlayGamePage } from "../pages/PlayGamePage.tsx";
import { HowToPlayPage } from "../pages/HowToPlayPage.tsx";
import type { AlertData } from "../App.tsx";
import { CreateNewGamePage } from "../pages/CreateNewGamePage.tsx";

interface AppRouterProps {
  showAlert: (data: AlertData) => void;
}

export const AppRouter: React.FC<AppRouterProps> = ({ showAlert }) => {
  return (
      <Routes>
        <Route path="/" element={<HomePage showAlert={showAlert} />} />
        <Route path="/how-to-play" element={<HowToPlayPage showAlert={showAlert} />} />
        <Route path="/play-game/:id" element={<PlayGamePage showAlert={showAlert} />} />
        <Route path="/create-game" element={<CreateNewGamePage showAlert={showAlert} />} />
        <Route path="/games" element={<GamesPage showAlert={showAlert} />} />
        <Route path="/characters" element={<CharactersPage showAlert={showAlert} />} />
        <Route path="/biomes" element={<BiomesPage showAlert={showAlert} />} />
        <Route path="/enemies" element={<EnemiesPage showAlert={showAlert} />} />
        <Route path="/items" element={<ItemsPage showAlert={showAlert} />} />
      </Routes>
  );
};
