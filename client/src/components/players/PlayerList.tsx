import React from "react";
import useFetchPlayers from "../../hooks/useFetchPlayers";
import PlayerItem from "./PlayerItem";
import styles from "./PlayerList.module.css";

export default function PlayerList() {
  const {
    list: players,
    error,
    isLoading,
  } = useFetchPlayers("http://localhost:5049/players");

  let content;

  if (error) {
    content = <p> {error}</p>;
  }

  if (isLoading) {
    content = <p>Loading data..</p>;
  }
  console.log(players);

  return (
    <div className={styles.mainContent}>
      {content}
      {players.map((player) => (
        <PlayerItem />
      ))}
    </div>
  );
}
