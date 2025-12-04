import React from 'react'

export const Header = () => {
  return (
    <header className=" bg-rose-800">
      <nav className="mx-auto flex items-center justify-between p-6">
        <div className="flex lg:flex-1">
          <a href="#" className="-m-1.5 p-1.5">
            <span className="sr-only">Your Company</span>
            <img src="https://images.vexels.com/media/users/3/326801/isolated/preview/a1c22a1b6fc6218aa769f0ae88dc2584-espada-de-dibujos-animados.png" alt="" className="h-8 w-auto" />
          </a>
        </div>

        <el-popover-group className="hidden lg:flex lg:gap-x-12">
          <a href="#" className="text-sm/6 font-semibold text-white">Games</a>
          <a href="#" className="text-sm/6 font-semibold text-white">Characters</a>
          <a href="#" className="text-sm/6 font-semibold text-white">Biomes</a>
          <a href="#" className="text-sm/6 font-semibold text-white">Enemys</a>
          <a href="#" className="text-sm/6 font-semibold text-white">Items</a>
        </el-popover-group>

        <div className="hidden lg:flex lg:flex-1 lg:justify-end">
          <a href="#" className="text-sm/6 font-semibold text-white">How to play <span aria-hidden="true">&rarr;</span></a>
        </div>
      </nav>
    </header>
  )
}
