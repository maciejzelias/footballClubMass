import { Route, Routes } from "react-router-dom";
import ContractList from "./components/contracts/ContractList";
import Footer from "./components/frgaments/Footer";
import MainContent from "./components/frgaments/MainContent";
import Navigation from "./components/frgaments/Navigation";
import PlayerList from "./components/players/PlayerList";

function App() {
  return (
    <>
      <Navigation />
      <Routes>
        <Route path="/" element={<MainContent />} />
        <Route path="/players" element={<PlayerList />} />
        <Route path="/contracts/:playerId" element={<ContractList />} />
      </Routes>
      <Footer />
    </>
  );
}

export default App;
