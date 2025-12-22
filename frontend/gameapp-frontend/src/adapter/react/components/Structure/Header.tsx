import React from 'react';
import { Link } from "react-router-dom";

export const Header: React.FC = () => {
  return (
    <header className="bg-custom-primary">
      <nav className="mx-auto flex items-center justify-between p-6">
        <div className="flex lg:flex-1">
          <a href="/" className="-m-1.5 p-1.5">
            <span className="sr-only">David Hernández</span>
            <img
              src="/images/logo_castillo_blanco.png"
              alt="Logo"
              className="h-12 w-auto"
            />
          </a>
        </div>

        <div className="hidden lg:flex lg:gap-x-12">
          <Link to="/games" className="text-sm/6 font-semibold text-custom-background">Games</Link>
          <Link to="/characters" className="text-sm/6 font-semibold text-custom-background">Characters</Link>
          <Link to="/biomes" className="text-sm/6 font-semibold text-custom-background">Biomes</Link>
          <Link to="/enemies" className="text-sm/6 font-semibold text-custom-background">Enemies</Link>
          <Link to="/items" className="text-sm/6 font-semibold text-custom-background">Items</Link>
        </div>

        <div className="hidden lg:flex lg:flex-1 lg:justify-end">
          <Link to="/how-to-play" className="text-sm/6 font-semibold text-custom-background">How to play <span aria-hidden="true">&rarr;</span></Link>
        </div>
      </nav>
    </header>
  );
};
