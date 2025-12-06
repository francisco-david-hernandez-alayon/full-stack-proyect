import React from 'react';

export const Header: React.FC = () => {
  return (
    <header className="bg-rose-800">
      <nav className="mx-auto flex items-center justify-between p-6">
        <div className="flex lg:flex-1">
          <a href="#" className="-m-1.5 p-1.5">
            <span className="sr-only">Your Company</span>
            <img
              src="/images/logo_castillo_blanco.png"
              alt="Logo"
              className="h-8 w-auto"
            />
          </a>
        </div>

        <div className="hidden lg:flex lg:gap-x-12">
          <a href="#" className="text-sm/6 font-semibold text-white">Games</a>
          <a href="#" className="text-sm/6 font-semibold text-white">Characters</a>
          <a href="#" className="text-sm/6 font-semibold text-white">Biomes</a>
          <a href="#" className="text-sm/6 font-semibold text-white">Enemys</a>
          <a href="#" className="text-sm/6 font-semibold text-white">Items</a>
        </div>

        <div className="hidden lg:flex lg:flex-1 lg:justify-end">
          <a href="#" className="text-sm/6 font-semibold text-white">
            How to play <span aria-hidden="true">&rarr;</span>
          </a>
        </div>
      </nav>
    </header>
  );
};
