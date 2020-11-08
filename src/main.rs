#![allow(non_snake_case)]
fn main() {
    println!("Elevator Start");

    let building = Building::new(10);
    let mut elevator = building.elevator;
    let reqAs = vec![(Direction::Up, 1),(Direction::Up, 2),(Direction::Up, 3),(Direction::Up, 4)];
    let reqBs = vec![(1,2), (2,4), (3,5), (4,6)]; //will do (a,b) a to b
    
}

pub enum Direction {
    Up,
    Down,
}
pub struct Building {
    floors:u8,
    elevator: Elevator,
}
pub struct Elevator {
    floor:u8,
    reqA: Vec<(Direction, u8)>,
    reqB: Vec<u8>,    
}

impl Building {
    pub fn new(floors: u8) -> Building {
        Building {
            floors: floors,
            elevator: Elevator::new()
        }
    }
}

impl Elevator {
    pub fn new() -> Elevator {
        Elevator {
            floor: 1,
            reqA: Vec::new(),
            reqB: Vec::new(),
        }
    }

    pub fn addReqA(&mut self, dir:Direction, currFloor:u8) {
        self.reqA.push((dir, currFloor))
    }
    pub fn addReqB(&mut self, to:u8) {
        self.reqB.push(to)
    }
    pub fn work(self) -> u8 {
        return self.floor
    }
}

/*
    Elevator must move reqB after reqA

    the request order : reqA -> reqB
    reqA is statement that 'Pressed call elevator button & wait for elevator'
    reqB is statement that 'Elevator arrived & pressed floor where do I go'

    Elevator must go reqAs in order

    if Elevator.floor on bottom & there're some reqAs
    -> list same direction(up,down) 
    -> make Up reqAs ascending, Down reqAs descending
    -> go to the first reqA & move only one direction untill reqAs that direction are all finished

    During elevator conducting reqB of reqA, if there are same direction reqA, then get those reqAs.
*/