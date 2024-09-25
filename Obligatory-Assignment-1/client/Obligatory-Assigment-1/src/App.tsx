import './App.css';
import Home from './pages/Home.tsx';
import { BrowserRouter, Route, Routes } from "react-router-dom";
import NotFound from "./pages/NotFound.tsx";
import NavBar from "./components/NavBar.tsx";
import Footer from "./components/Footer.tsx";

function App() {
    return (
        <>
            <BrowserRouter>
                <NavBar />
                <div>
                    <div className="m-2 pt-1">
                        <Routes>
                            <Route path={'/'} element={<Home />} />
                            <Route path={'/home'} element={<Home />} />
                            <Route path={'/*'} element={<NotFound />} />
                        </Routes>
                    </div>
                </div>
                <Footer />
            </BrowserRouter>
        </>
    );
}

export default App;
