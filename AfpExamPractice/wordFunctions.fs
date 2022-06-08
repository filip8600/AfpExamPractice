
module wordFunctions
open word
open System.Collections.Generic


    let wordArray= words.Split "\r\n"
    let wordList= List.ofArray wordArray
    let wordsLite=List.map (fun (elem:string)-> elem[0..3]) wordList
    let hashLite=HashSet<string>(wordsLite)

    let wordHash=HashSet<string>(wordList)
    //let dict =Dictionary<char,string[]>()
    //let a= List.fold (fun acc elem-> (
    //    dict.Add(elem[0],elem
    //    0))) 0 wordList

    let anyWordsContains (letters:string)=
    //    wordHash.exists (fun (a: string)->(a.StartsWith letters)) wordHash
        true

    let verifyWord (word:string)=
        let exists=wordHash.Contains word 
        if exists then 
            word+" "
        else
            ""
  
let verifyWordLite (word:string)=
    hashLite.Contains word 