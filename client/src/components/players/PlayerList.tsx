import React from "react";
import useFetchList from "../../hooks/useFetchList";
import PlayerItem from "./PlayerItem";
import styles from "./PlayerList.module.css";

export interface Player {
  age: number;
  birthdayYear: number;
  countOfTitles: number;
  id: number;
  name: string;
  surname: string;
}

export default function PlayerList() {
  const {
    list: players,
    error,
    isLoading,
  } = useFetchList<Player>("http://localhost:5049/players");

  let content = <p className={styles.title}>Pick a player</p>;

  if (error) {
    content = <p> {error}</p>;
  }

  if (isLoading) {
    content = <p>Loading data..</p>;
  }

  return (
    <div className={styles.mainContent}>
      {content}
      {players.map((player) => (
        <PlayerItem player={player} key={player.id} />
      ))}
    </div>
  );
}
