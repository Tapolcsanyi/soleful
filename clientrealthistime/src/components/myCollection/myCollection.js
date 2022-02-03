import React, { useEffect, useState } from "react";
import { getAllUserSneakers } from '../../modules/userSneakerManager';
import { UserSneakerCard } from "./userSneakerCard";

export const UserSneakerList = () => {
    const [sneakers, setSneakers] = useState([]);

    const getSneakers = () => {
        return getAllUserSneakers().then(sneakers => {
            setSneakers(sneakers)
        });
    };

    useEffect(() => {
        getSneakers();
    }, []);

    let pp = sneakers.filter( (ele, ind) => ind === sneakers.findIndex( elem => elem.SneakerId === ele.jobid && elem.id === ele.id))

    console.log(pp)

    return (
        <> <div>
            <div>{sneakers.map(usneaker => <UserSneakerCard key={usneaker.id} usneaker={usneaker} />)}</div>
        </div>
        </>
    )
}
export default UserSneakerList;