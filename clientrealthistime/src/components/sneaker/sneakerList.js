import React, { useEffect, useState } from "react";
import SneakerCard from "./sneakerCard";
import { getAllSneakers } from '../../modules/sneakerManager';
import { _getUserData } from "../../modules/authManager";
import { Button } from "reactstrap";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";
import { getLoggedInUser } from "../../modules/userManager";

export const SneakerList = () => {
    const [sneakers, setSneakers] = useState([]);
    const [user, setUser] = useState({});

    const history = useHistory();

    const getSneakers = () => {
        return getAllSneakers().then(sneakers => {
            setSneakers(sneakers)
        });
    };

    useEffect(() => {
        getSneakers();
        getLoggedInUser().then(user => setUser(user))
    }, []);

    const handleShoeButton = () => {
        if(user.userTypeId == 1){
            console.log(user.userTypeId)
     history.push("/createshoe")
        } else {
            console.log(user.userTypeId)
        }
      }

    return (
        <>
        <Button onClick={handleShoeButton}>BRuh</Button>
        <div>
            <div>{sneakers.map(sneaker => <SneakerCard key={sneaker.id} sneaker={sneaker} />)}</div>
        </div>
        </>
    )
}
export default SneakerList;