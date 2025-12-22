import type React from "react";
import type { Biome } from "../../../../domain/enumerates/biome";

interface BiomeCardProps {
    biome: Biome;
    description: string;
    color?: string;
    image?: string;
}

export const BiomeCard: React.FC<BiomeCardProps> = ({ biome, description, color, image }) => {
    return (
        <div
            className="card shadow-md p-8 max-w-full flex flex-col items-center bg-background"
            style={{ backgroundColor: color }}
        >
            {image && (
                <img
                    src={image}
                    alt={biome}
                    className="w-32 h-32 object-contain mb-4"
                />
            )}

            <h2 className="card-title text-custom-background text-center mb-2">
                {biome}
            </h2>

            <p className="text-custom-background text-center">
                {description}
            </p>
        </div>
    );
};
