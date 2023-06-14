import React from "react";
import { useNavigate } from "react-router-dom";
import styles from "./MainContent.module.css";

export default function MainContent() {
  const navigate = useNavigate();
  const handleOnClick = () => {
    navigate("/players");
  };
  return (
    <div className={styles.mainContent}>
      <button className={styles.button} onClick={handleOnClick}>
        Players
      </button>
    </div>
  );
}
