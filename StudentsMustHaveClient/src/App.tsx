import "./App.css";
import { Route, BrowserRouter as Router, Routes } from "react-router-dom";
import Navbar from "./containers/Navbar";
import Login from "./containers/Login";

function App() {
  return (
    <>
      <Router>
        <Navbar />

        <Routes>
          <Route path="/login" element={<Login />} />
        </Routes>
      </Router>
    </>
  );
}

export default App;
