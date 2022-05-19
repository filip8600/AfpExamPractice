open System.Collections.Generic
open System
open System.Linq
open word


// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

let kurt="-...-....-.--."
let morseToLetter = Map.ofList[( ".-", 'a')
;( "-...", 'b')
;( "-.-.", 'c')
;( "-..", 'd')
;( ".", 'e')
;( "..-.", 'f')
;( "--.", 'g')
;( "....", 'h')
;( "..", 'i')
;( ".---", 'j')
;( "-.-", 'k')
;( ".-..", 'l')
;( "--", 'm')
;( "-.", 'n')
;( "---", 'o')
;( ".--.", 'p')
;( "--.-", 'q')
;( ".-.", 'r')
;( "...", 's')
;( "-", 't')
;( "..-", 'u')
;( "...-", 'v')
;( ".--", 'w')
;( "-..-", 'x')
;( "-.--", 'y')
;( "--..", 'z')]


let rev map:Map<char,string>=
    Map.fold (fun m key value->m.Add(value,key)) Map.empty map
let lettersToMorse= rev morseToLetter


let rec parse (morse:string) (result:string)=

    let length =(String.length morse)
    let resultLen=(String.length result)

    let check1 (morse1:string) (result1:string)=
        let localLenght= result1.Length
        match result1[localLenght-2..localLenght-1] with
            |"tt" ->""
            |"ee" ->""
            |_->
                match morseToLetter.ContainsKey morse1[0..0] with
                    |true-> 
                        let letter=morseToLetter.Item (morse1[0..0])
                        (parse morse1[1.. length-1] (result1+(string letter))) 
                    |_-> ""
    let check2 (morse1:string) result1=
        match morseToLetter.ContainsKey morse1[0..1] with
            |true-> 
                let letter=morseToLetter.Item (morse1[0..1])
                (parse morse1[2.. length-1] (result1+string letter)) 
            |_-> ""
    let check3 (morse1:string) result1=
        match morseToLetter.ContainsKey morse1[0..2] with
            |true-> 
                let letter=morseToLetter.Item (morse1[0..2])
                (parse morse1[3.. length-1] (result1+string letter)) 
            |_-> ""
    let check4 (morse1:string) result1=
        match morseToLetter.ContainsKey morse1[0..3] with
            |true-> 
                let letter=morseToLetter.Item (morse1[0..3])

                (parse morse1[4.. length-1] (result1+string letter)) 
            |_-> ""

    match anyWordsContains result with
        | false-> ""
        | true->
            match length with
                | 0 -> verifyWord result
                | 1-> check1 morse result
                | 2-> 
                    let a=check1 morse result
                    let b=check2 morse result
                    a+b
                | 3-> 
                    let a=check1 morse result
                    let b=check2 morse result
                    let c =check3 morse result
                    a+b+c
                | _-> 
                    let a=check1 morse result
                    let b=check2 morse result
                    let c =check3 morse result
                    let d= check4 morse result
                    a+b+c+d


 
//let result=parse kurt ""
//Console.WriteLine result
let convertToMorse word=
    String.collect (fun elem->( lettersToMorse.Item elem)) word

let kurt2= List.fold (fun acc elem->(
        let morse=convertToMorse elem
        let result=parse morse ""
        Console.WriteLine result
        if ((result.Split " ").Length=5 )then result else acc))  "start " wordList[0..100]
Console.WriteLine kurt2