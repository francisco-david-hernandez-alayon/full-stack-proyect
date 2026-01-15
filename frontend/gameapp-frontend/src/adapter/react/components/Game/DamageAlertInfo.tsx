import { useEffect, useState } from "react";
import { Sword, Skull } from "lucide-react";

export interface DamageAlertInfoProps {
  userDamage: number;
  enemyDamage: number;
  onClose: () => void;
}

const DAMAGE_ALERT_DURATION = 3000; // 3 seconds

export const DamageAlertInfo: React.FC<DamageAlertInfoProps> = ({
  userDamage,
  enemyDamage,
  onClose,
}) => {
  const [visible, setVisible] = useState(true);

  useEffect(() => {
    const timer = setTimeout(() => {
      setVisible(false);
      onClose?.();
    }, DAMAGE_ALERT_DURATION);
    return () => clearTimeout(timer);
  }, [onClose]);

  if (!visible) return null;

  return (
    <div className="fixed top-10 left-1/2 -translate-x-1/2">

      <div className="alert bg-custom-background flex flex-col items-center justify-center text-center gap-3 max-w-md">

        {/* Player damage */}
        <div className="flex gap-2">
          <Sword className="w-4 h-4 text-green-400" />
          <span>
            You dealt{" "}
            <strong className="text-green-400">
              {userDamage}
            </strong>{" "}
            damage
          </span>
        </div>

        {/* Divider */}
        <div className="w-full flex justify-center">
          <div className="h-px w-full bg-custom-primary" />
        </div>


        {/* Enemy damage */}
        <div className="flex items-center gap-2">
          <Skull className="w-4 h-4 text-red-400" />
          <span>
            The enemy dealt{" "}
            <strong className="text-red-400">
              {enemyDamage}
            </strong>{" "}
            damage
          </span>
        </div>

      </div>
    </div>
  );
};
