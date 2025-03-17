import React from "react";
import "./Navbar.css";
import {FaUserCircle} from "react-icons/fa"; //Iconita pentru utilizator
import logo from "./logo.png";

const Navbar = () => {
return(
 <nav className = "navbar">
    <div className = "navbar-logo">
        <img src = {logo} alt = "FIFA World Cup 2026"/>
        <span>FIFA World Cup 2026</span>
        <span className="countries">CANADA | MEXICO | UNITATED STATES OF AMERICA </span>
    </div>
    <ul className="navbar-links">
        <li><a href ="#">Stadiums</a></li>
        <li><a href ="#">Buy Tickets</a></li>
        <li><a href ="#">Matches</a></li>
        <li><a href ="#">About</a></li>
        <li>
            <a href ="#" className="user-link">
                Log In / Sign Up <FaUserCircle className="user-icon"/>
            </a>
        </li>
    </ul>
    </nav>
);
};

export default Navbar;