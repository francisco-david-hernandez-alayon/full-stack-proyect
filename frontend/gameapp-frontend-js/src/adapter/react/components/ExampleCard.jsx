import React from "react";

export const ExampleCard = ({
  title = "Tarjeta de prueba para tailwind",
  description = "Esta es una tarjeta impresionante que muestra cómo Tailwind puede crear componentes ultra estilizados sin CSS adicional.",
  tags = ["React", "Tailwind", "Vite"],
  imageUrl = "https://images.unsplash.com/photo-1602524810811-2469b8c0d9d1?auto=format&fit=crop&w=800&q=80",
}) => {
  return (
    <div className="max-w-sm md:max-w-md lg:max-w-lg bg-linear-to-r from-purple-600 via-pink-500 to-red-500 rounded-3xl shadow-2xl overflow-hidden transform hover:scale-105 transition-transform duration-500">
      <img
        src={imageUrl}
        alt={title}
        className="w-full h-48 object-cover rounded-t-3xl border-b-4 border-white"
      />
      <div className="p-6 bg-white">
        <h2 className="text-2xl font-bold text-gray-800 mb-3">{title}</h2>
        <p className="text-gray-600 mb-4">{description}</p>

        <div className="flex flex-wrap gap-2 mb-4">
          {tags.map((tag, idx) => (
            <span
              key={idx}
              className="bg-purple-100 text-purple-800 px-3 py-1 rounded-full text-sm font-medium hover:bg-purple-200 transition-colors duration-300 cursor-pointer"
            >
              {tag}
            </span>
          ))}
        </div>

        <div className="flex justify-between items-center">
          <button className="bg-linear-to-r from-pink-500 to-purple-600 text-white font-semibold px-5 py-2 rounded-full shadow-lg hover:shadow-xl transform hover:scale-105 transition-all duration-300">
            ¡Vamos!
          </button>
          <span className="text-gray-400 text-sm">Hace 2 horas</span>
        </div>
      </div>
    </div>
  );
};
