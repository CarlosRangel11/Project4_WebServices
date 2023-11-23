<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
				xmlns:ps="https://www.public.asu.edu/~carange4/Parks.xsd">
	<xsl:output method="html" />
	<xsl:template match="/">
		<html>
			<body>
				<xsl:apply-templates select="ps:Parks/ps:Park" />
			</body>
		</html>
	</xsl:template>

	<xsl:template match="ps:Park">
		<div>
			<strong>Name: </strong>
			<xsl:value-of select="ps:Name" />
			<br/>
			<strong>Type: </strong>
			<xsl:value-of select="@type" />
			<br/>
			<strong>Owner: </strong>
			<xsl:value-of select="ps:Owner" />
			<br/>
			<strong>Address: </strong>
			<xsl:value-of select="ps:Reservation/ps:Address"/>
			<br/>
			<strong>URL: </strong>
			<a href="{ps:Reservation/ps:Url}">
				<xsl:value-of select="ps:Reservation/ps:Url"/>
			</a>
			<br/>
			<strong>Neighboring States: </strong>
			<xsl:value-of select="ps:Neighboring_States"/>
			<br/>
			<strong>Established in: </strong>
			<xsl:value-of select="ps:Established_In"/>
			<br/>
			<br/>
		</div>
	</xsl:template>
</xsl:stylesheet>


