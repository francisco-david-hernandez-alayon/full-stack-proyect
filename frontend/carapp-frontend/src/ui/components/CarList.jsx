import React, { useEffect, useState } from "react";
import { CarService } from "../../application/services/CarService";
import { Car } from "../../domain/entities/Car";


export const CarList = () => {
  const [cars, setCars] = useState([]);

  useEffect(() => {
    CarService.getCars().then(data => {
      const carsObjects = data.map(c => new Car(c.id, c.brand, c.model));
      setCars(carsObjects);


    }).catch(err => {
      console.error("Error fetching cars:", err);
      setCars([]);
    });
  }, []);

  return (
    <div style={{ padding: "20px", fontFamily: "Arial, sans-serif" }}>
      <h2 style={{ color: "#2c3e50" }}>🚗 Lista de Coches</h2>
      {cars.length === 0 ? (
        <p>No hay coches disponibles.</p>
      ) : (
        <ul style={{ listStyle: "none", padding: 0 }}>
          {cars.map(c => (
            <li 
              key={c.id} 
              style={{
                background: "#ecf0f1", 
                margin: "8px 0", 
                padding: "10px", 
                borderRadius: "6px",
                boxShadow: "0 1px 3px rgba(0,0,0,0.1)"
              }}
            >
              <strong>{c.brand}</strong> - {c.model}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};
