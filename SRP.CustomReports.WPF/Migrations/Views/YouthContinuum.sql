WITH activities as (
	SELECT 
		Individuals.Id as IndividualId,
		ActivityStudyItemIndividuals.IndividualRole,
		StudyItems.ActivityStudyItemType
	FROM dbo.Individuals
	INNER JOIN dbo.ActivityStudyItemIndividuals ON
		Individuals.Id = ActivityStudyItemIndividuals.IndividualId
	INNER JOIN dbo.StudyItems ON
		ActivityStudyItemIndividuals.StudyItemId = StudyItems.Id
), participation as (
	SELECT
		IndividualId,
		SUM(CASE WHEN IndividualRole IN (0, 5, 6) AND ActivityStudyItemType = 'Book' THEN 1 ELSE 0 END) as BooksFacilitated,
		SUM(CASE WHEN IndividualRole = 7 AND ActivityStudyItemType = 'Book' THEN 1 ELSE 0 END) as BooksStudied,
		SUM(CASE WHEN IndividualRole IN (0, 3, 4) AND ActivityStudyItemType = 'Grade' THEN 1 ELSE 0 END) as TextsFacilitated,
		SUM(CASE WHEN IndividualRole = 7 AND ActivityStudyItemType = 'Grade' THEN 1 ELSE 0 END) as TextsStudied,
		SUM(CASE WHEN IndividualRole IN (0, 1, 2) AND ActivityStudyItemType = 'Text' THEN 1 ELSE 0 END) as GradesFacilitated,
		SUM(CASE WHEN IndividualRole = 7 AND ActivityStudyItemType = 'Text' THEN 1 ELSE 0 END) as GradesStudied
	FROM
		activities
	GROUP BY
		IndividualId
)
SELECT 
	Individuals.Id,
	CONCAT(Individuals.FirstName,' ', Individuals.FamilyName) as [Individual],
	Localities.Name as [Locality],
	Clusters.Name as [ClusterName],
	Clusters.Id as [ClusterId],
	Groupings.GroupName,
	Groupings.Id as [GroupId],
	CASE WHEN Individuals.Comments LIKE '%#YIC%' THEN 1 ELSE 0 END as [YIC],
	CASE WHEN Individuals.Comments LIKE '%#YEI%' THEN 1 ELSE 0 END as [YEI],
	CASE WHEN Individuals.Comments LIKE '%#YCA%' THEN 1 ELSE 0 END as [YCA],
	CASE WHEN Individuals.Comments LIKE '%#YAO%' THEN 1 ELSE 0 END as [YAO],
	CASE WHEN participation.GradesStudied > 0 THEN 1 ELSE 0 END as [AttendedCC],
	CASE WHEN participation.GradesFacilitated > 0 THEN 1 ELSE 0 END as [TaughtCC],
	CASE WHEN participation.TextsStudied > 0 THEN 1 ELSE 0 END as [AttendedJYG],
	CASE WHEN participation.TextsFacilitated > 0 THEN 1 ELSE 0 END as [AnimatedJYG],
	CASE WHEN participation.BooksStudied > 0 THEN 1 ELSE 0 END as [AttendedSC],
	CASE WHEN participation.BooksFacilitated > 0 THEN 1 ELSE 0 END as [TutoredSC]
FROM 
	dbo.Individuals
INNER JOIN dbo.Localities ON
	Individuals.LocalityId = Localities.Id
INNER JOIN dbo.Clusters ON
	Localities.ClusterId = Clusters.Id
LEFT OUTER JOIN participation ON
	Individuals.Id = participation.IndividualId
LEFT OUTER JOIN dbo.ClusterGroupings ON
	Clusters.Id = ClusterGroupings.ClusterId
LEFT OUTER JOIN dbo.Groupings ON
	ClusterGroupings.GroupingId = Groupings.Id
WHERE 
	Individuals.EstimatedYearOfBirthDate >= (YEAR(GETDATE())-30)
AND Individuals.IsArchived = 0
