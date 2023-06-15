import React from "react";
import styles from "./PlayerItem.module.css";
import { Player } from "./PlayerList";
import { Link } from "react-router-dom";

const PlayerItem: React.FC<{ player: Player }> = ({ player }) => {
  return (
    <Link className={styles.player} to={`/contracts/${player.id}`}>
      <p>Name: {player.name}</p>
      <p>Surname: {player.surname}</p>
    </Link>
  );
};

export default PlayerItem;
