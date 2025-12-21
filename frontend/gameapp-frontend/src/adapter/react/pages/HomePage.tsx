import type { AlertData } from "../App";

interface HomePageProps {
  showAlert: (data: AlertData) => void;
}

export const HomePage: React.FC<HomePageProps> = ({ showAlert }) => {
    return (
        <>
            <div className="p-6">
                <h1 className="text-custom-primary-title">HOME</h1>
            </div>
        </>
    );
};