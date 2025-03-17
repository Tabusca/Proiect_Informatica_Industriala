import React from "react";
import "./HeroSection.css";

const HeroSection = () => {
  return (
    <header className="hero">
        <div className="hero-content">
            <h1>Welcome to the 2026 FIFA World Cup!</h1>
            <p>The world's most anticipated football event is almost here, and we are thrilled to bring you all the excitement and actions live from the heart of the competition.</p>
            <p>In 2026, the World Cup will be hosted across three nations-Canada, Mexico and the United States - creating a thrilling atmosphere and celebrating the global unity that only football can inspire.</p>
            <p>Stay up-to-date with the match schedules, and live results, and get ready to experience the unforgettable moments that will define this year's tournament.</p>
            <p>Explore teams, player profiles, and detailed information about each stadium.</p>
            <p>Whether you'are a die-hard football fan or just tuning in for the first time, we have everything you need to follow your favorite teams and witness history in the making.</p>
            <p>Get your tickets, secure your spot at the matches, and join us in celebrating the beautiful game!</p>
            <button className = "buy-tickets">Buy Tickets</button>
        </div>
    </header>
  );
};

export default HeroSection;