import { Routes, Route } from "react-router-dom";
import { HomePage } from "../pages/HomePage.tsx";
import { GamesPage } from "../pages/GamesPage.tsx";
import { CharactersPage } from "../pages/CharactersPage.tsx";
import { BiomesPage } from "../pages/BiomesPage.tsx";
import { EnemiesPage } from "../pages/EnemiesPage.tsx";
import { ItemsPage } from "../pages/ItemsPage.tsx";
import { PlayGamePage } from "../pages/PlayGamePage.tsx";
import { HowToPlayPage } from "../pages/HowToPlayPage.tsx";

export const AppRouter: React.FC = () => {
  return (
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/how-to-play" element={<HowToPlayPage />} />
        <Route path="/play-game/:id" element={<PlayGamePage />} />
        <Route path="/games" element={<GamesPage />} />
        <Route path="/characters" element={<CharactersPage />} />
        <Route path="/biomes" element={<BiomesPage />} />
        <Route path="/enemies" element={<EnemiesPage />} />
        <Route path="/items" element={<ItemsPage />} />
      </Routes>
  );
};
